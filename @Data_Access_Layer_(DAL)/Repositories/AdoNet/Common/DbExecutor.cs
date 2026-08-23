using DVLD.DAL.Common;
using DVLD.DAL.Entities;
using DVLD.DAL.Mapper;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;
namespace DVLD.DAL.Repo.ADONet
{
    internal static class DbExecutor
    {
        /// <summary>
        /// Validates the provided SqlCommand object to ensure it is not null and has a valid CommandText.
        /// </summary>
        /// <param name="command">The SqlCommand to validate.</param>
        /// <param name="callerName">The name of the calling method.</param>
        /// <exception cref="ArgumentNullException">SQLCommand cannot be null.</exception>
        /// <exception cref="ArgumentException">CommandText cannot be empty or whitespace.</exception>
        /// <returns>Throw an exception if the command is invalid.</returns>
        private static async Task IsValidCommand(
            SqlCommand? command,
            [CallerMemberName] string callerName = "")
        {
            if (command is null)
            {
                await Logs.AppendLog(
                    Logs.enType.Error,
                    $"[{DateTime.Now}] - SqlCommand is null in operation: {callerName}"
                );
                throw new ArgumentNullException(nameof(command), "SqlCommand cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(command.CommandText))
            {
                await Logs.AppendLog(
                    Logs.enType.Error,
                    $"[{DateTime.Now}] - CommandText is empty or whitespace in operation: {callerName}"
                );
                throw new ArgumentException("CommandText cannot be empty or whitespace.", nameof(command));
            }
        }
        /// <summary>
        /// Executes a command and returns a single entity mapped from the result set.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity to return.</typeparam>
        /// <typeparam name="TIndices">The type of column indices.</typeparam>
        /// <param name="command">SQLCommand Cannot be null and the query cannot be empty or just spaces</param>
        /// <param name="mapper">The function to map the data reader to an entity.</param>
        /// <returns>The mapped entity or null if no rows are found.</returns>
        internal async static Task<TEntity?> ExecuteReaderSingleAsync<TEntity, TIndices>(
        SqlCommand command,
        Func<SqlDataReader, TIndices, Task<TEntity>> mapper)
        where TEntity : class, new()
        where TIndices : IColumnIndices<TIndices>
        {
            await IsValidCommand(command);

            TEntity? result = null;

            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                if (command.Connection == null)
                {
                    command.Connection = connection;
                }

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows && await reader.ReadAsync())
                        {
                            TIndices indices = TIndices.Create(reader);
                            result = await mapper(reader, indices);
                        }
                    }
                }
                catch (Exception ex)
                {
                    await Logs.AppendLog(
                        Logs.enType.Error,
                        $"[{DateTime.Now}] - Error message: {ex.Message}"
                    );
                    throw;
                }
            }

            return result;
        }
        /// <summary>
        /// Executes a command and returns a list of entities mapped from the result set.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity to return.</typeparam>
        /// <typeparam name="TIndices">The type of column indices.</typeparam>
        /// <param name="command">SQLCommand Cannot be null and the query cannot be empty or just spaces</param>
        /// <param name="mapper">The function to map the data reader to an entity.</param>
        /// <returns>A list of entities mapped from the result set.</returns>
        internal async static Task<List<TEntity>> ExecuteReaderListAsync<TEntity, TIndices>(
        SqlCommand command,
        Func<SqlDataReader, TIndices, Task<TEntity>> mapper)
        where TEntity : class
        where TIndices : IColumnIndices<TIndices>
        {
            List<TEntity> list = new List<TEntity>();

            await IsValidCommand(command);

            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                if (command.Connection == null)
                {
                    command.Connection = connection;
                }

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            TIndices indices = TIndices.Create(reader);
                            while (await reader.ReadAsync())
                            {
                                list.Add(await mapper(reader, indices));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    await Logs.AppendLog(
                        Logs.enType.Error,
                        $"[{DateTime.Now}] - Error message: {ex.Message}"
                    );
                    throw;
                }
            }

            return list;
        }
        /// <summary>
        /// Executes a command and returns the first column of the first row in the result set as an integer.
        /// </summary>
        /// <param name="command">SQLCommand Cannot be null and the query cannot be empty or just spaces</param>
        /// <returns>The first column of the first row in the result set as an integer.</returns>
        internal async static Task<int> ExecuteScalarReturnInt(SqlCommand command)
        {
            await IsValidCommand(command);

            int result = -1;

            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                if (command.Connection == null)
                {
                    command.Connection = connection;
                }

                try
                {
                    await connection.OpenAsync();

                    object? value = await command.ExecuteScalarAsync();

                    if (value != null && int.TryParse(value.ToString(), out int parsedResult))
                    {
                        result = parsedResult;
                    }
                }
                catch (Exception ex)
                {
                    await Logs.AppendLog(
                        Logs.enType.Error,
                        $"[{DateTime.Now}] - Error message: {ex.Message}"
                    );
                    throw;
                }
            }

            return result;
        }
        /// <summary>
        /// Executes a command and returns a boolean value.
        /// TRUE If the command returns 1, FALSE if it returns 0 or null.
        /// </summary>
        /// <param name="command">SQLCommand Cannot be null and the query cannot be empty or just spaces</param>
        /// <returns></returns>
        internal async static Task<bool> ExecuteCommandReturnBoolean(SqlCommand command)
        {
            await IsValidCommand(command);

            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                if (command.Connection == null)
                {
                    command.Connection = connection;
                }
                try
                {
                    await connection.OpenAsync();

                    object? result = await command.ExecuteScalarAsync();

                    if (result == null)
                    {
                        return false;
                    }

                    return (int.TryParse(result.ToString(), out int value) && value == 1);
                }
                catch (Exception ex)
                {
                    await Logs.AppendLog(
                        Logs.enType.Error,
                        $"[{DateTime.Now}] - Error message: {ex.Message}"
                    );

                    throw;
                }
            }
        }
        /// <summary>
        /// Executes a command and returns the number of rows affected.
        /// </summary>
        /// <param name="command">The SqlCommand to execute.</param>
        /// <returns>The number of rows affected.</returns>
        internal async static Task<int> ExecuteCommandReturnRowsAffected(SqlCommand command)
        {
            await IsValidCommand(command);

            int rowsAffected = -1;

            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                if (command.Connection == null)
                {
                    command.Connection = connection;
                }
                try
                {
                    await connection.OpenAsync();

                    rowsAffected = await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    await Logs.AppendLog(
                        Logs.enType.Error,
                        $"[{DateTime.Now}] - Error message: {ex.Message}"
                    );
                    throw;
                }
            }
            return rowsAffected;
        }
    }
}