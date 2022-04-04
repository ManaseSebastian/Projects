package manase.sebastian.actions;

import manase.sebastian.windows.PasswordRecoveryWindow;

public class Chronometer extends Thread {

    @Override
    public void run() {
        PasswordRecoveryWindow window = PasswordRecoveryWindow.getInstance();
        window.getButton().setEnabled(false);
        int value = 10;
        for (int i = value; i >= 0; i--) {
            try {
                window.getChronometerLabel().setText("Time remained: " + i);
                Thread.sleep(1000);
            } catch (InterruptedException exception) {
                exception.printStackTrace();
            }
        }
        window.getButton().setEnabled(true);
        window.getPasswordTextField().setText("");
        window.getNameTextField().setText("");
        window.getChronometerLabel().setText("");
    }
}