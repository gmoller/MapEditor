using System.Windows.Forms;
using GameData;
using GameLogic;

namespace WinFormsGui
{
    public partial class SettlementForm : Form
    {
        private Settlement _settlement;

        public SettlementForm()
        {
            InitializeComponent();
        }

        public void SetData(Settlement settlement)
        {
            _settlement = settlement;

            Text = $@"{settlement.SettlementType} of {settlement.Name}";
            lblRace.Text = $@"Race: {settlement.RaceName}";
            lblPopulation.Text = $@"Population: {settlement.Population} (+{settlement.GrowthRate})";
            lblResidents.Text = BuildResidentsString(settlement);
            SetResources(settlement);
            SetBuildings(settlement);
            SetProduceBuilding(settlement);
        }

        private string BuildResidentsString(Settlement settlement)
        {
            string residents = string.Empty;
            for (int i = 0; i < settlement.SubsistenceFarmers; i++)
            {
                residents += "F";
            }
            residents += " ";
            for (int i = 0; i < settlement.AdditionalFarmers; i++)
            {
                residents += "F";
            }
            for (int i = 0; i < settlement.TotalWorkers; i++)
            {
                residents += "W";
            }
            residents += " ";
            for (int i = 0; i < settlement.TotalRebels; i++)
            {
                residents += "R";
            }

            return residents.Trim();
        }

        private void SetResources(Settlement settlement)
        {
            lstResources.Items.Add($"Food: Consumption - {settlement.FoodConsumption}, Surplus - {settlement.FoodSurplus}");
            lstResources.Items.Add($"Production: {settlement.Production}");
        }

        private void SetBuildings(Settlement settlement)
        {
            foreach (BuildingType item in settlement.BuildingThatHaveBeenBuilt)
            {
                lstBuildings.Items.Add(item.Name);
            }
        }

        private void SetProduceBuilding(Settlement settlement)
        {
            cboProduceBuilding.Items.Add("Trade Goods");
            cboProduceBuilding.Items.Add("Housing");
            BuildingTypes canCurrentlyBuild = settlement.CanCurrentlyBuild;
            foreach (BuildingType item in canCurrentlyBuild)
            {
                cboProduceBuilding.Items.Add(item.Name);
            }

            cboProduceBuilding.SelectedIndex = _settlement.CurrentlyProducing.Id;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void cboProduceBuilding_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _settlement.CurrentlyProducing = Globals.Instance.BuildingTypes[(string)cboProduceBuilding.SelectedItem];
        }
    }
}