package manase.sebastian.actions;

import manase.sebastian.model.User;
import manase.sebastian.windows.CreateAccountWindow;
import manase.sebastian.windows.LoginWindow;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.FileWriter;
import java.io.IOException;

public class ActionCreate implements ActionListener {

    @Override
    public void actionPerformed(ActionEvent e) {
        createEncryptFile("src/main/java/files/accounts.txt");
    }

    private void createEncryptFile(String path) {
        CreateAccountWindow window = CreateAccountWindow.getInstance();
        String name = window.getNameTextField().getText();
        String password = String.valueOf(window.getPasswordField().getPassword());
        int age = (int) window.getAgeSpinner().getValue();

        User user = new User(name, password, age);
        if (verifyUser(user)) {
            for (User tmpUser : LoginWindow.getUsers()) {
                if (tmpUser.equals(user)) {
                    JOptionPane.showMessageDialog(window, "The user already exist", "Information", JOptionPane.WARNING_MESSAGE);
                    return;
                }
            }
            LoginWindow.getUsers().add(user);
            User encryptUser = new User(Encoder.encrypt(name, age), Encoder.encrypt(password, age), age);
            try (final FileWriter encryptFile = new FileWriter(path, true)) {
                encryptFile.write(encryptUser.toString());
                JOptionPane.showMessageDialog(window, "Account Created", "Information", JOptionPane.INFORMATION_MESSAGE);
                window.getNameTextField().setText("");
                window.getPasswordField().setText("");
            } catch (IOException ex) {
                System.out.println("There is a problem with the <<account.txt>> file" + ex.getMessage());
            }
        }
    }

    private boolean verifyUser(User user) {
        String type = "";
        if (user.getName().equals("")) {
            type = "UserName";
        } else {
            if (user.getPassword().equals("")) {
                type = "Password";
            } else
                return true;
        }
        JOptionPane.showMessageDialog(CreateAccountWindow.getInstance(), "Input the: " + type, "Information", JOptionPane.WARNING_MESSAGE);
        return false;
    }
}
