using System.Collections.Generic;
using System.Linq;
using Concentration.lib;

public class MenuManager : EntityManager{

    public List<Button> MenuButtons = new List<Button>();
    public MenuManager(List<Button> buttons) {
        foreach (Button button in buttons) {
            RegisterEntity(button);
            MenuButtons.Add(button);
        }
    }

    public void ClearMenu() {
        foreach(Button button in queryEntitiesOfType<Button>()) {
            DespawnEntity(button);
        }
    }

    public void OpenMenu() {
        foreach (Button button in MenuButtons) {
            if (!queryEntitiesOfType<Button>().Contains(button)) {
                RegisterEntity(button);
            }
        }
    }

}