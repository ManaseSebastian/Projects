package manase.sebastian.actions;

import manase.sebastian.windows.DefaultWindow;
import manase.sebastian.windows.PasswordRecoveryWindow;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class ActionOpenRecoveryWindow implements ActionListener {

    @Override
    public void actionPerformed(ActionEvent e) {
        DefaultWindow window = PasswordRecoveryWindow.getInstance();
        if (!window.isVisible()) {
            window.setVisible(true);
        }
    }
}
