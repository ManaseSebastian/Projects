package manase.sebastian.actions;

import manase.sebastian.windows.CreateAccountWindow;
import manase.sebastian.windows.DefaultWindow;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class ActionOpenCreateWindow implements ActionListener {

    @Override
    public void actionPerformed(ActionEvent e) {
        DefaultWindow window = CreateAccountWindow.getInstance();
        if (!window.isVisible()) {
            window.setVisible(true);
        }
    }
}
