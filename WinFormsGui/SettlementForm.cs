using System.Windows.Forms;
using GameLogic;

namespace WinFormsGui
{
    public partial class SettlementForm : Form
    {
        public SettlementForm()
        {
            InitializeComponent();
        }

        public void SetData(Settlement settlement)
        {
            Text = $@"{settlement.SettlementType} of {settlement.Name}";
            lblRace.Text = $@"Race: {settlement.RaceName}";
            lblPopulation.Text = $@"Population: {settlement.Population} (+{settlement.GrowthRate})";
            lblResidents.Text = BuildResidentsString(settlement);
            SetResources(settlement);
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
    }
}