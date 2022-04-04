package manase.sebastian.actions;

public class Encoder {

    public static String encrypt(String s, int code) {
        StringBuilder temp = new StringBuilder();
        for (int i = 0; i < s.length(); i++) {
            temp.append((char) (s.charAt(i) - code));
        }
        return temp.toString();
    }

    public static String decrypt(String s, int code) {
        StringBuilder temp = new StringBuilder();
        for (int i = 0; i < s.length(); i++) {
            temp.append((char) (s.charAt(i) + code));
        }
        return temp.toString();
    }
}
