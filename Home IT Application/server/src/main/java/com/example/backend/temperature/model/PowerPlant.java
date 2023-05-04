package com.example.backend.temperature.model;

public class PowerPlant extends Thread {
    private static PowerPlant instance;
    private Double desiredTemperature;
    private Double currentTemperature;
    private boolean isPowerPlantWorking;

    private PowerPlant() {
        this.desiredTemperature = 20.0;
        this.currentTemperature = 20.0;
        this.isPowerPlantWorking = false;
    }

    public static PowerPlant getInstance() {
        if (instance == null) {
            instance = new PowerPlant();
        }
        return instance;
    }

    public Double getCurrentTemperature() {
        return this.currentTemperature;
    }

    public Double getDesiredTemperature() {
        return this.desiredTemperature;
    }

    public void setDesiredTemperature(double desiredTemperature) {
        this.desiredTemperature = desiredTemperature;
    }

    public void setCurrentTemperature(double currentTemperature) {
        this.currentTemperature = currentTemperature;
    }

    public void setPowerPlantWorking(boolean isPowerPlantWorking) {
        this.isPowerPlantWorking = isPowerPlantWorking;
    }

    public boolean isPowerPlantWorking() {
        return this.isPowerPlantWorking;
    }

    public void startPowerPlant() {
        this.start();
    }

    public void start() {
        if (!this.isPowerPlantWorking) {
            this.isPowerPlantWorking = true;
            while (this.currentTemperature < this.desiredTemperature + 0.5 && this.isPowerPlantWorking) {
                this.currentTemperature += 0.1;
                try {
                    Thread.sleep(2000);
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }
            }
            this.isPowerPlantWorking = false;
        }
    }

}
