using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimConsole;
using Simulator;

namespace SimWeb.Pages
{
    public class SimulationModel : PageModel
    {
        private readonly SimulationHistory _simulationHistory;
        public SimulationState CurrentState { get; set; }
        public int CurrentTurn { get; set; }

        public SimulationModel(SimulationHistory simulationHistory)
        {
            _simulationHistory = simulationHistory;
            CurrentTurn = 0;  // Initialize to turn 0 or retrieve the current turn from the history.
        }

        public void OnGet()
        {
            // Fetch the simulation state for the current turn
            try
            {
                CurrentState = _simulationHistory.GetStateAtTurn(CurrentTurn);
            }
            catch (ArgumentException)
            {
                // If no simulation state exists for the turn, leave CurrentState null
                CurrentState = null;
            }
        }

        public IActionResult OnPostNext()
        {
            // Logic for moving to the next turn
            CurrentTurn++;
            try
            {
                CurrentState = _simulationHistory.GetStateAtTurn(CurrentTurn);
            }
            catch (ArgumentException)
            {
                CurrentState = null;
            }
            return Page();  // Re-render the page after changing the state
        }

        public IActionResult OnPostPrevious()
        {
            // Logic for moving to the previous turn
            if (CurrentTurn > 0)
            {
                CurrentTurn--;
                try
                {
                    CurrentState = _simulationHistory.GetStateAtTurn(CurrentTurn);
                }
                catch (ArgumentException)
                {
                    CurrentState = null;
                }
            }
            return Page();  // Re-render the page after changing the state
        }
    }
}
