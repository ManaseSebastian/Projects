import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:home_automation/auth/login/local/auth_shared_preferences.dart';
import 'package:home_automation/auth/recovery_password/screens/confirmation_screen.dart';
import 'package:home_automation/auth/register/register_screen.dart';
import 'package:home_automation/features/doors/doors_screen.dart';
import 'package:home_automation/features/garage/garage_screen.dart';
import 'package:home_automation/features/home/home_screen.dart';
import 'package:home_automation/features/settings/settings_screen.dart';
import 'package:home_automation/features/temperature/temperature_screen.dart';

import 'auth/login/screens/login_screen.dart';
import 'auth/recovery_password/screens/recovery_password_screen.dart';
import 'features/light/light_screen.dart';
import 'features/security/security_screen.dart';
import 'package:firebase_core/firebase_core.dart';

void main() async{
  WidgetsFlutterBinding.ensureInitialized();
  await AuthSharedPreferences.init();
  Firebase.initializeApp();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      title: 'Flutter Demo',
      home: LoginScreen(),
    );
  }
}
