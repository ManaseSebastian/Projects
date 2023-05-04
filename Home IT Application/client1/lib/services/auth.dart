import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';

class AuthService {
  final FirebaseAuth _auth = FirebaseAuth.instance;

  Future<User?> signIn(BuildContext context, VoidCallback onSuccess,
      String mail, String password) async {
    try {
      UserCredential result = await _auth.signInWithEmailAndPassword(
          email: mail, password: password);
      onSuccess.call();
      User? user = result.user;

      return user;
    } catch (e) {
      return null;
    }
  }

  Future<void> signOut() async {
    await _auth.signOut();
  }

  Future register(String mail, String password) async {
    try {
      await _auth.createUserWithEmailAndPassword(
          email: mail, password: password);
    } catch (e) {
      print(e.toString());
      return null;
    }
  }

  Future changePassword(BuildContext context, VoidCallback onSuccess,
      String code, String newPassword) async {
    try {
      await _auth.confirmPasswordReset(code: code, newPassword: newPassword);
    } catch (e) {
      print(e.toString());
      return null;
    }
  }

  Future recoveryPassword(String mail) async {
    try {
      await _auth.sendPasswordResetEmail(email: mail);
    } catch (e) {
      print(e.toString());
      return null;
    }
  }
}
