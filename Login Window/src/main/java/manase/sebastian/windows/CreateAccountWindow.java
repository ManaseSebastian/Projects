package manase.sebastian.windows;

import javax.swing.*;

public class CreateAccountWindow extends DefaultWindow {

    private JSpinner ageSpinner;
    private static CreateAccountWindow createAccountWindow;

    private CreateAccountWindow() {
        initializationWindow();
    }

    public static CreateAccountWindow getInstance() {
        if (createAccountWindow == null) {
            createAccountWindow = new CreateAccountWindow();
        }
        return createAccountWindow;
    }

    @Override
    public void initializationWindow() {
        this.setDefaultCloseOperation(HIDE_ON_CLOSE);
        this.setLocation(310, 0);
        this.setTitle("CreateAccount");
        int x = 50;
        int y = 25;
        int height = 35;
        //Create Spinner
        SpinnerModel value = new SpinnerNumberModel(10, 1, 100, 1);
        this.ageSpinner = new JSpinner(value);
        this.ageSpinner.setBounds(200, y + 5 * height - 25, 50, 30);

        //Create Label
        JLabel ageLabel = new JLabel("Age: ");
        ageLabel.setBounds(x, y + 5 * height - 25, 50, 30);

        this.getButton().setText("Create");
        this.add(ageLabel);
        this.add(this.ageSpinner);
        this.setVisible(true);
    }

    public JSpinner getAgeSpinner() {
        return this.ageSpinner;
    }

}
