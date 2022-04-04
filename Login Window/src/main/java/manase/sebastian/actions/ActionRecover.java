package manase.sebastian.actions;

import manase.sebastian.model.User;
import manase.sebastian.windows.CreateAccountWindow;
import manase.sebastian.windows.LoginWindow;
import manase.sebastian.windows.PasswordRecoveryWindow;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

public class ActionRecover implements ActionListener {

    //Compare a temporary user created (it has just name from nameTextField) with the users stored in ArrayList.
    @Override
    public void actionPerformed(ActionEvent e) {
        ArrayList<User> users = LoginWindow.getUsers();
        PasswordRecoveryWindow window = PasswordRecoveryWindow.getInstance();
        String name = window.getNameTextField().getText();
        if (!name.equals("")) {
            User tmpUser = new User(name, "", 0);
            for (User user : users) {
                if (tmpUser.equals(user)) {
                    window.getPasswordTextField().setText(user.getPassword());
                    new Chronometer().start();
                    return;
                }
            }
            JOptionPane.showMessageDialog(CreateAccountWindow.getInstance(), "The user does not exist.", "Information", JOptionPane.WARNING_MESSAGE);

        } else {
            JOptionPane.showMessageDialog(CreateAccountWindow.getInstance(), "Input a UserName ", "Information", JOptionPane.WARNING_MESSAGE);
        }
    }
}