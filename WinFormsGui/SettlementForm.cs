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
            lblPopulation.Text = $@"Population: {settlement.Residents} (+{settlement.GrowthRate})";
            lblResidents.Text = BuildResidentsString(settlement.Population);
            SetResources(settlement);
        }

        private string BuildResidentsString(Population settlementPopulation)
        {
            string residents = string.Empty;
            for (int i = 0; i < settlementPopulation.SubsistenceFarmers; i++)
            {
                residents += "F";
            }
            residents += " ";
            for (int i = 0; i < settlementPopulation.AdditionalFarmers; i++)
            {
                residents += "F";
            }
            for (int i = 0; i < settlementPopulation.Workers; i++)
            {
                residents += "W";
            }
            for (int i = 0; i < settlementPopulation.Rebels; i++)
            {
                residents += "R";
            }

            return residents;
        }

        private void SetResources(Settlement settlement)
        {
            lstResources.Items.Add($"Food: Consumption - {settlement.FoodConsumption}, Surplus - {settlement.FoodSurplus}");
        }
    }
}