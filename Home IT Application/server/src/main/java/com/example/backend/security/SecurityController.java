package com.example.backend.security;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping(path = "api/security")
public class SecurityController {

    @Autowired
    private SecurityService securityService;

    @PostMapping(path = "/scheduleAlarm")
    public void setAlarm(@RequestBody String alarm) {
        this.securityService.scheduleAlarm(alarm);
    }

    @GetMapping(path = "/getStateAlarm")
    public boolean getStateAlarm() {
        return this.securityService.getStateAlarm();
    }

    @GetMapping(path = "/turnOnAlarm")
    public void turnOnAlarm() {
        this.securityService.setStateAlarm(true);
    }

    @GetMapping(path = "/turnOffAlarm")
    public void turnOffAlarm() {
        this.securityService.setStateAlarm(false);
    }
}
