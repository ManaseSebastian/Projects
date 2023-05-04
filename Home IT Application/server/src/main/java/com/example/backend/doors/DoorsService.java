package com.example.backend.doors;

import org.springframework.stereotype.Service;

import java.time.Duration;
import java.time.LocalTime;

@Service
public class DoorsService {
    private boolean isLocked;
    private String PIN = "0000";

    public boolean getStateDoors() {
        return this.isLocked;
    }

    public void setStateDoors(boolean isLocked) {
        this.isLocked = isLocked;
    }

    public void scheduleLock(String lock) {
        Duration duration = Duration.between(LocalTime.parse(lock), LocalTime.now());
        if (!duration.isNegative()) {
            this.isLocked = true;
        }
    }

    public void verifyPINLock(String lock) {
        if (PIN.equals(lock)) {
            this.isLocked = false;
        }
    }

    public void setPINLock(String PIN) {
        this.PIN = PIN;
    }



}
