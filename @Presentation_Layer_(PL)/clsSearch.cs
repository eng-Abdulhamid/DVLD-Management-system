namespace DVLDPL.General
{
    public class clsSearch : UserControl 
    {
        protected void _FillSearchTypeComboBox(ref CustomControls.ModernComboBox cbSerachType)
        {
            cbSerachType.Items.Add("Please Select");
            cbSerachType.Items.Add("Contain");
            cbSerachType.Items.Add("Start with");
            cbSerachType.Items.Add("End with");
            cbSerachType.SelectedIndex = 0;
        }
        protected void _FillComboBoxSearchFiltering(List<string> SearchFilterFields, ref ModernComboBox ComboBox)
        {
            foreach (string str in SearchFilterFields)
            {
                ComboBox.Items.Add(str);
            }
            ComboBox.SelectedIndex = 0;
        }
        protected enSearchType _MapStingTOSearchTypeEnum(string SearchType)
        {
            switch (SearchType.ToLower())
            {
                case "contain":
                    {
                        return enSearchType.Contain;
                    }
                case "start with":
                    {
                        return enSearchType.StartWith;
                    }
                case "end with":
                    {
                        return enSearchType.EndWith;
                    }
                default:
                    {
                        return enSearchType.None;
                    }
            }
        }
        protected enSorting _MapStringToSortingEnum(string SortingString)
        {
            switch (SortingString.ToLower())
            {
                case "asc":
                    {
                        return enSorting.Ascending;
                    }
                case "desc":
                    {
                        return enSorting.Descending;
                    }
                default:
                    {
                        return enSorting.Ascending;
                    }
            }
        }
    }
}
