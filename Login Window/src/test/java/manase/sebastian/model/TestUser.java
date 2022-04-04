package manase.sebastian.model;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class TestUser {

    @Test
    void testConstructor() {
        User user = new User("Sebi", "Password", 20);

        assertEquals("Sebi", user.getName());
        assertEquals("Password", user.getPassword());
        assertEquals(20, user.getAge());
    }

    @Test
    void testSetName() {
        User user = new User("Sebi", "Password", 20);

        user.setName("Mihai");
        assertEquals("Mihai", user.getName());
    }

    @Test
    void testSetPassword() {
        User user = new User("Sebi", "Password", 20);

        user.setPassword("Password1");
        assertEquals("Password1", user.getPassword());
    }

    @Test
    void testToString() {
        User user = new User("Sebi", "Password", 20);

        assertEquals("User name= Sebi password= Password age= 20\n", user.toString());
    }

    @Test
    void testEquals() {
        User user1 = new User("Sebi", "Password", 20);
        User user2 = new User("Sebi", "Password2", 22);
        User user3 = new User("Sebastian", "Password", 20);

        assertTrue(user2.equals(user1));
        assertFalse(user1.equals(user3));
        assertFalse(user2.equals(user3));
    }
}
