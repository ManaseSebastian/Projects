package manase.sebastian.actions;

import manase.sebastian.model.User;
import manase.sebastian.windows.DefaultWindow;
import manase.sebastian.windows.LoginWindow;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;

public class ActionLogin implements ActionListener {

    @Override
    public void actionPerformed(ActionEvent e) {
        DefaultWindow window = LoginWindow.getInstance();
        ArrayList<User> users = LoginWindow.getUsers();
        String name = window.getNameTextField().getText();
        String password = String.valueOf(window.getPasswordField().getPassword());
        User tmpUser = new User(name, password, 0);
        for (User user : users) {
            if (user.equals(tmpUser)) {
                if (tmpUser.getPassword().equals(user.getPassword())) {
                    rememberUser(user);
                    JOptionPane.showMessageDialog(window, "Congratulation!", "Information", JOptionPane.INFORMATION_MESSAGE);
                    window.getNameTextField().setText("");
                    window.getPasswordField().setText("");
                } else {
                    JOptionPane.showMessageDialog(window, "Wrong Password try \n <<Forget password?>>", "Information", JOptionPane.WARNING_MESSAGE);
                }
                return;
            }
        }
        JOptionPane.showMessageDialog(window, "Wrong Username", "Information", JOptionPane.WARNING_MESSAGE);
    }

    private void rememberUser(User user) {
        String path = "src/main/java/files/remember.txt";
        LoginWindow window = LoginWindow.getInstance();
        if (window.getRememberCheckBox().isSelected()) {
            try (FileWriter file = new FileWriter(path)) {
                user.setName(Encoder.encrypt(user.getName(), user.getAge()));
                user.setPassword(Encoder.encrypt(user.getPassword(), user.getAge()));
                file.write(user.toString());
                user.setName(Encoder.decrypt(user.getName(), user.getAge()));
                user.setPassword(Encoder.decrypt(user.getPassword(), user.getAge()));
            } catch (IOException ex) {
                System.out.println("There are a problem with the Remember file" + ex.getMessage());
            }
        }
    }
}