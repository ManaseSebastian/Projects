package manase.sebastian.windows;

import manase.sebastian.actions.Encoder;
import manase.sebastian.model.User;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.assertArrayEquals;
import static org.junit.jupiter.api.Assertions.assertEquals;

public class TestLoginWindow {

    @Test
    void testGetUserDetails() {
        String s = "User name= Sebi password= Password age= 20";
        LoginWindow window = LoginWindow.getInstance();

        User user = window.getUserDetails(s);

        assertEquals(Encoder.decrypt("Sebi", 20), user.getName());
        assertEquals(Encoder.decrypt("Password", 20), user.getPassword());
        assertEquals(20, user.getAge());
    }

    @Test
    void testGetUsers() {
        User user1 = new User("Sebi", "Password", 20);
        User user2 = new User("Sebi", "Password2", 22);
        User user3 = new User("Sebastian", "Password", 20);
        ArrayList<User> users = new ArrayList<>();
        users.add(user1);
        users.add(user2);
        users.add(user3);
        LoginWindow.getUsers().add(user1);
        LoginWindow.getUsers().add(user2);
        LoginWindow.getUsers().add(user3);

        assertArrayEquals(users.toArray(), LoginWindow.getUsers().toArray());
    }
}
