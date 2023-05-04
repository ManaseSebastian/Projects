package com.example.backend.temperature;

import com.example.backend.temperature.model.PowerPlant;
import org.springframework.stereotype.Service;

@Service
public class TemperatureService {


    public Double getCurrentTemperature() {
        return PowerPlant.getInstance().getCurrentTemperature();
    }

    public Double getDesiredTemperature() {
        return PowerPlant.getInstance().getDesiredTemperature();
    }

    public void setDesiredTemperature(double desiredTemperature) {
        PowerPlant.getInstance().setDesiredTemperature(desiredTemperature);
        double currentTemperature = PowerPlant.getInstance().getCurrentTemperature();
        if (currentTemperature <= desiredTemperature - 0.5) {
            this.startPowerPlant();
        }
    }

    public void setCurrentTemperature(double currentTemperature) {
        PowerPlant.getInstance().setCurrentTemperature(currentTemperature);
        double desiredTemperature = PowerPlant.getInstance().getDesiredTemperature();
        if (currentTemperature <= desiredTemperature - 0.5) {
            this.startPowerPlant();
        }
    }

    public void setPowerPlantWorking(boolean isPowerPlantWorking) {
        PowerPlant.getInstance().setPowerPlantWorking(isPowerPlantWorking);
    }

    public boolean isPowerPlantWorking() {
        return PowerPlant.getInstance().isPowerPlantWorking();
    }

    public void startPowerPlant() {
        PowerPlant.getInstance().startPowerPlant();
    }
}
