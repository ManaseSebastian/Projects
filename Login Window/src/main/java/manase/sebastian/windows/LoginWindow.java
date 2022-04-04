package manase.sebastian.windows;

import manase.sebastian.actions.Encoder;
import manase.sebastian.model.User;

import javax.swing.*;
import java.awt.*;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class LoginWindow extends DefaultWindow {

    private final static ArrayList<User> users = new ArrayList<>();
    private static LoginWindow loginWindow;
    private JButton forgetPasswordButton;
    private JButton createAccountButton;
    private JCheckBox rememberCheckBox;

    private LoginWindow() {
        initializationWindow();
        readUsers();
        remember();
    }

    public static LoginWindow getInstance() {
        if (loginWindow == null) {
            loginWindow = new LoginWindow();
        }
        return loginWindow;
    }

    @Override
    public void initializationWindow() {
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setTitle("Login");
        this.getButton().setText("Login");
        int x = 50;
        int y = 25;
        int height = 35;

        this.rememberCheckBox = new JCheckBox("Remember me", false);
        this.rememberCheckBox.setBounds(x, y + 4 * height, 150, height);

        this.forgetPasswordButton = new JButton("Forgot password?");
        this.forgetPasswordButton.setBounds(x - 25, y + 6 * height + 15, 150, height);
        buttonToLabel(forgetPasswordButton);

        this.createAccountButton = new JButton("Create Account");
        this.createAccountButton.setBounds(x + 85, y + 6 * height + 15, 150, height);
        buttonToLabel(createAccountButton);

        this.add(rememberCheckBox);
        this.add(this.forgetPasswordButton);
        this.add(this.createAccountButton);
        this.setVisible(true);
    }

    //Transform a button to look like a label
    private void buttonToLabel(JButton button) {
        button.setBorderPainted(false);
        button.setContentAreaFilled(false);
        button.setForeground(Color.blue);
    }

    private void readUsers() {
        final String path = "src/main/java/files/accounts.txt";
        try (BufferedReader file = new BufferedReader(new FileReader(path))) {
            String line = file.readLine();
            while (line != null) {
                User tmpUser = getUserDetails(line);
                users.add(tmpUser);
                line = file.readLine();
            }
        } catch (IOException e) {
        }
    }

    private void remember() {
        final String path = "src/main/java/files/remember.txt";
        try (BufferedReader file = new BufferedReader(new FileReader(path))) {
            String line = file.readLine();
            User user = getUserDetails(line);
            this.getNameTextField().setText(user.getName());
            this.getPasswordField().setText(user.getPassword());
        } catch (IOException ex) {
            // System.out.println("There is a problem with the <<remember.txt>> file" + ex.getMessage());
        }
    }

    public User getUserDetails(String line) {
        try {
            String name = line.substring(line.indexOf("name") + 6, line.indexOf("password") - 1);
            String password = line.substring(line.indexOf("password") + 10, line.indexOf("age") - 1);
            int age = Integer.parseInt(line.substring(line.indexOf("age") + 5));
            User tmpUser = new User(Encoder.decrypt(name, age), Encoder.decrypt(password, age), age);
            return tmpUser;
        } catch (NumberFormatException | StringIndexOutOfBoundsException ex) {
            System.out.println("There is a problem with <<accounts.txt>> " + ex.getMessage());
        }
        return null;
    }

    public JButton getForgetPasswordButton() {
        return forgetPasswordButton;
    }

    public JButton getCreateAccountButton() {
        return createAccountButton;
    }

    public static ArrayList<User> getUsers() {
        return users;
    }

    public JCheckBox getRememberCheckBox() {
        return rememberCheckBox;
    }
}
