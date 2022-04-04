package manase.sebastian.controller;

import manase.sebastian.actions.*;
import manase.sebastian.windows.CreateAccountWindow;
import manase.sebastian.windows.DefaultWindow;
import manase.sebastian.windows.LoginWindow;
import manase.sebastian.windows.PasswordRecoveryWindow;

public class Controller {

    public void control() {
        LoginWindow window1 = LoginWindow.getInstance();
        window1.getButton().addActionListener(new ActionLogin());
        window1.getForgetPasswordButton().addActionListener(new ActionOpenRecoveryWindow());
        window1.getCreateAccountButton().addActionListener(new ActionOpenCreateWindow());

        DefaultWindow window2 = CreateAccountWindow.getInstance();
        window2.getButton().addActionListener(new ActionCreate());
        window2.setVisible(false);

        window2 = PasswordRecoveryWindow.getInstance();
        window2.getButton().addActionListener(new ActionRecover());
        window2.setVisible(false);
    }
}
