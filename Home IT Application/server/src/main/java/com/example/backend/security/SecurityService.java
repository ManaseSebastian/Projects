package com.example.backend.security;

import org.springframework.stereotype.Service;

import java.time.Duration;
import java.time.LocalTime;

@Service
public class SecurityService {
    private boolean isOn;

    public SecurityService() {
        this.isOn = false;
    }

    public void scheduleAlarm(String alarm) {
        String[] alarms = alarm.split("-");

        LocalTime start = LocalTime.parse(alarms[0]);
        LocalTime stop = LocalTime.parse(alarms[1]);
        Duration duration1 = Duration.between(start, LocalTime.now());
        Duration duration2 = Duration.between(LocalTime.now(), stop);
        if (!duration1.isNegative() && !duration2.isNegative()) {
            this.isOn = true;
            return;
        }
        this.isOn = false;
    }

    public boolean getStateAlarm() {
        return this.isOn;
    }

    public void setStateAlarm(boolean isOn) {
        this.isOn = isOn;
    }
}
