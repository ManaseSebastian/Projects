package manase.sebastian.windows;

import javax.swing.*;

public class PasswordRecoveryWindow extends DefaultWindow {

    private static PasswordRecoveryWindow passwordRecoveryWindow;
    private JTextField passwordTextField;
    private JLabel chronometerLabel;

    private PasswordRecoveryWindow() {
        initializationWindow();
    }

    public static PasswordRecoveryWindow getInstance() {
        if (passwordRecoveryWindow == null) {
            passwordRecoveryWindow = new PasswordRecoveryWindow();
        }
        return passwordRecoveryWindow;
    }

    @Override
    public void initializationWindow() {
        this.setDefaultCloseOperation(HIDE_ON_CLOSE);
        this.setLocation(620, 0);
        this.setTitle("Recovery Password");
        this.getButton().setText("Recover Password");
        this.remove(this.getPasswordField());

        passwordTextField = new JTextField();
        passwordTextField.setEditable(false);
        chronometerLabel = new JLabel();

        int x = 50;
        int y = 25;
        int height = 35;
        this.setSizes(passwordTextField, x, y + 3 * height, height);
        this.setSizes(chronometerLabel, x, y + 4 * height, height);
        this.add(passwordTextField);
        this.add(chronometerLabel);
        this.setVisible(true);
    }

    public JTextField getPasswordTextField() {
        return passwordTextField;
    }

    public JLabel getChronometerLabel() {
        return chronometerLabel;
    }
}
