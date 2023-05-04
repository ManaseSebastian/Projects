package com.example.backend.doors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping(path = "api/doors")
public class DoorsController {

    @Autowired
    private DoorsService doorsService;

    @GetMapping(path = "/lockDoors")
    public void lockDoors() {
        this.doorsService.setStateDoors(true);
    }

    @GetMapping(path = "/unlockDoors")
    public void unlockDoors() {
        this.doorsService.setStateDoors(false);
    }

    @GetMapping(path = "/getStateDoors")
    public boolean getStateDoors() {
        return this.doorsService.getStateDoors();
    }

    @PostMapping(path = "/scheduleLock")
    public void setScheduleLock(@RequestBody String lock) {
        this.doorsService.scheduleLock(lock);
    }

    @PostMapping(path = "/verifyPINLock")
    public void verifyPINLock(@RequestBody String lock) {
        this.doorsService.verifyPINLock(lock);
    }

    @PostMapping(path = "/setPINLock")
    public void setPINLock(@RequestBody String lock) {
        this.doorsService.setPINLock(lock);
    }


}
