package manase.sebastian.windows;

import javax.swing.*;
import java.awt.*;

public abstract class DefaultWindow extends JFrame {

    private JLabel nameLabel;
    private JLabel passwordLabel;
    private JTextField nameTextField;
    private JPasswordField passwordField;
    private JButton button;

    public DefaultWindow() {
        defaultSettings();
    }

    // Default Settings for all the windows
    public void defaultSettings() {
        this.setSize(310, 350);
        this.setResizable(false);
        this.setLayout(null);

        this.nameLabel = new JLabel("Name");
        this.passwordLabel = new JLabel("Password");
        this.nameTextField = new JTextField();
        this.passwordField = new JPasswordField();
        this.button = new JButton();

        int x = 50;
        int y = 25;
        int height = 35;

        setSizes(this.getNameLabel(), x, y, height);
        setSizes(this.getNameTextField(), x, y + height, height);
        setSizes(this.getPasswordLabel(), x, y + 2 * height, height);
        setSizes(this.getPasswordField(), x, y + 3 * height, height);
        setSizes(this.getButton(), x, y + 5 * height + 10, height);
    }

    public void setSizes(Component component, int x, int y, int height) {
        int width = 210;
        component.setBounds(x, y, width, height);
        this.add(component);
    }

    //Particular settings for each window
    public abstract void initializationWindow();

    public JLabel getNameLabel() {
        return nameLabel;
    }

    public JLabel getPasswordLabel() {
        return passwordLabel;
    }

    public JTextField getNameTextField() {
        return nameTextField;
    }

    public JPasswordField getPasswordField() {
        return passwordField;
    }

    public JButton getButton() {
        return button;
    }

}
