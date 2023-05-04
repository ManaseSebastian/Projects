package com.example.backend.temperature;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping(path = "api/temperature")
public class TemperatureController {
    @Autowired
    private TemperatureService temperatureService;

    @GetMapping(path = "/getCurrentTemperature")
    public String getCurrentTemperature() {
        return this.temperatureService.getCurrentTemperature().toString();
    }

    @PostMapping(path = "/setCurrentTemperature")
    public void setCurrentTemperature(@RequestBody String currentTemperature) {
        this.temperatureService.setCurrentTemperature(Double.parseDouble(currentTemperature));
    }

    @GetMapping(path = "/getDesiredTemperature")
    public String getDesiredTemperature() {
        return this.temperatureService.getDesiredTemperature().toString();
    }

    @PostMapping(path = "/setDesiredTemperature")
    public void setDesiredTemperature(@RequestBody String desiredTemperature) {
        this.temperatureService.setDesiredTemperature(Double.parseDouble(desiredTemperature));
    }

    @GetMapping(path = "/startPowerPlant")
    public void startPowerPlant() {
        this.temperatureService.startPowerPlant();
    }

    @GetMapping(path = "/stopPowerPlant")
    public void stopPowerPlant() {
        this.temperatureService.setPowerPlantWorking(false);
    }

    @GetMapping(path = "/isPowerPlantWorking")
    public boolean isPowerPlantWorking() {
        return this.temperatureService.isPowerPlantWorking();
    }
}
