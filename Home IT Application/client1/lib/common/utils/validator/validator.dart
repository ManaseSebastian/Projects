class Validator {
  static String? validateUsername(String? s) {
    if (s == null || s.isEmpty) {
      return "The Username is required.";
    }
    return null;
  }

  static String? validatePassword(String? s) {
    if (s == null || s.isEmpty) {
      return "The Password is required.";
    }
    return null;
  }

  static String? validateConfirmPassword(String? s, String? s1) {
    String? message = validatePassword(s);
    if (message != null) {
      return message;
    }
    if (s != s1) {
      return "Confirmation password doesn't match.";
    }
    return null;
  }

  static String? validateMail(String? s) {
    if (s == null || s.isEmpty) {
      return "The mail is required.";
    }
    bool mailValid = RegExp(
            r"^[a-zA-Z0-9.a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9]+.[a-zA-Z]+")
        .hasMatch(s);
    if (!mailValid) {
      return "The email format is incorrect.";
    }
    return null;
  }

  static String? validateCode(String? s) {
    if (s == null || s.isEmpty) {
      return "The confirmation code is required.";
    }
    bool codeValid = RegExp(r'^\d{1,4}$')
        .hasMatch(s);
    if (!codeValid) {
      return "The code has 4 digits.";
    }
    return null;
  }

  static String? validateDoubleNumber(String? s) {
    if (s == null || s.isEmpty) {
      return "A number is required.";
    }
    bool codeValid =  RegExp(r'(^\d*\.?\d*)')
        .hasMatch(s);
    if (!codeValid) {
      return "The number is not double";
    }
    return null;
  }

  static String? validate2InOut(String? s) {
    if (s == null || s.isEmpty) {
      return "A number is required.";
    }
    bool codeValid =  RegExp(r'/^(?=.*[0-9])(?=.*[0-9])$/')
        .hasMatch(s);
    if (!codeValid) {
      return "The number has not just 2 digits.";
    }
    return null;
  }

}
