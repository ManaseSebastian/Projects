package manase.sebastian.actions;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class TestEncoder {

    @Test
    void testEncrypt() {
        String s = "name";
        int code = 1;

        assertEquals("m`ld", Encoder.encrypt(s, code));
    }

    @Test
    void testDecrypt() {
        String s = "m`ld";
        int code = 1;

        assertEquals("name", Encoder.decrypt(s, code));
    }
}
