using DTOs;
using DVLD_BusinessLogicLayer;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPL
{
    public partial class ctrlSearchItems : UserControl
    {
        protected string LastSearchText { get; set; } = string.Empty; 

        public ctrlSearchItems()
        {
            InitializeComponent();
            btnSearch.Enabled = false;
            FillComboBoxSearchFiltering();
            FillComboBoxSearchTypes();
            InitializeSearchFiltering();
        }
        public void InitializeSearchFiltering()
        {
            LastSearchText = string.Empty;
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = string.Empty;
            }
            if (cbSearchFiltering.Items.Count > 0)
            {
                cbSearchFiltering.SelectedIndex = 0;
            }
            if (cbSearchType.Items.Count > 0)
            {
                cbSearchType.SelectedIndex = 0;
            }
            if (cbSorting.Items.Count > 0)
            {
                cbSorting.SelectedIndex = 0;
            }
        }
        protected virtual void FillComboBoxSearchTypes()
        {
            cbSearchType.Items.Add("Please Select");
            cbSearchType.Items.Add("Contain");
            cbSearchType.Items.Add("Start with");
            cbSearchType.Items.Add("End with");
            cbSearchType.SelectedIndex = 0;
        }
        protected virtual enSearchType MapSelectedSearchTypeTOSearchTypeEnum()
        {
            switch (cbSearchType.Text.ToLower())
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
        protected virtual enSorting MapSelectedSortingByToSortingEnum()
        {
            switch (cbSorting.Text.ToLower())
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LastSearchText = txtSearch.Text;
        }
        protected virtual void FillComboBoxSearchFiltering()
        {
        }
        private void btnClearSearchFiltering_Click(object sender, EventArgs e)
        {
            InitializeSearchFiltering();
        }
        private Random rand = new Random();
        private void _ChangeButtonSearchBorderColorRandomly()
        {
            List<Color> Colors = new List<Color>()
            {
                Color.AliceBlue,
                Color.AntiqueWhite,
                Color.Aqua,
                Color.Aquamarine,
                Color.Azure,
                Color.Beige,
                Color.BlanchedAlmond,
                Color.MediumAquamarine,
                Color.Beige,
                Color.Bisque,
                Color.Black,
                Color.BlanchedAlmond,
                Color.Blue,
                Color.BlueViolet,
                Color.Brown,
                Color.BurlyWood,
                Color.AliceBlue, Color.DarkBlue,Color.CadetBlue,Color.CornflowerBlue,Color.DarkCyan,Color.DarkGoldenrod,Color.DarkGreen,Color.DarkKhaki,Color.DarkMagenta,Color.DarkOliveGreen,Color.DarkOrange,Color.DarkOrchid,Color.DarkRed,Color.DarkTurquoise,Color.DarkViolet
            };
            btnSearch.GeneralBorderColor = Colors[rand.Next(0, Colors.Count - 1)];
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = !string.IsNullOrEmpty(txtSearch.Text) && (txtSearch.Text != LastSearchText);
            if (btnSearch.Enabled)
            {
                if ((cbSearchFiltering.SelectedIndex == 0) && (cbSearchType.SelectedIndex == 0))
                {
                    cbSearchFiltering.SelectedIndex = 1;
                    cbSearchType.SelectedIndex = 2;
                }
                _ChangeButtonSearchBorderColorRandomly();
            }
        }
        private void cbSearchFiltering_SelectedIndexChanged(object sender, EventArgs e)
        {
            LastSearchText = string.Empty;
        }
        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
