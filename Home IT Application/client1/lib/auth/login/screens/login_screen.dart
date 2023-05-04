import 'package:firebase_auth/firebase_auth.dart';

import 'package:flutter/material.dart';
import 'package:home_automation/auth/auth_main_screen.dart';
import 'package:home_automation/auth/login/local/auth_shared_preferences.dart';
import 'package:home_automation/auth/login/local/pref_constants.dart';
import 'package:home_automation/auth/recovery_password/screens/recovery_password_screen.dart';
import 'package:home_automation/common/app_constants.dart';
import 'package:home_automation/common/utils/validator/validator.dart';
import 'package:home_automation/features/home/home_screen.dart';

import '../../../services/auth.dart';
import '../../widgets/auth_checkbox.dart';
import '../../widgets/auth_input_field.dart';

class LoginScreen extends StatefulWidget {
  const LoginScreen({Key? key}) : super(key: key);

  @override
  State<LoginScreen> createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  bool _isButtonEnable = false;
  bool _isAuth = false;

  bool validateForm() {
    return (Validator.validateUsername(_usernameController.text) == null &&
        Validator.validatePassword(_passwordController.text) == null);
  }

  @override
  void initState() {
    super.initState();
    if (AuthSharedPreferences.instance
        .getBool(key: PreferencesConstants.rememberMeKey)) {
      _usernameController.text = AuthSharedPreferences.instance
          .getString(key: PreferencesConstants.usernameKey);
      _passwordController.text = AuthSharedPreferences.instance
          .getString(key: PreferencesConstants.passwordKey);
    }
    if (validateForm()) {
      _isButtonEnable = true;
    }
  }

  void _handleLoginButton() async {
    AuthService service = AuthService();
    User? user = await service.signIn(context, () {
      if (!mounted) return;
      Navigator.pushReplacement(
        context,
        MaterialPageRoute(
          builder: (_) => const HomeScreen(),
        ),
      );

    },
        _usernameController.text, _passwordController.text);
    if (user != null) {
      print("USEREUL ESTE: ${user?.email})");
      _isAuth = true;
      if (AuthSharedPreferences.instance
          .getBool(key: PreferencesConstants.rememberMeKey)) {
        AuthSharedPreferences.instance.setString(
            PreferencesConstants.usernameKey, _usernameController.text);
        AuthSharedPreferences.instance.setString(
            PreferencesConstants.passwordKey, _passwordController.text);
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return AuthMainScreen(
      backgroundImage: const AssetImage('images/login_background.png'),
      textButton: 'Login',
      isButtonEnable: _isButtonEnable,
      hasBottomText: true,
      hasBackButton: false,
      action: _handleLoginButton,
      centerWidget: SizedBox(
        height: 200,
        child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 20),
          child: Form(
            onChanged: () => setState(() {
              _isButtonEnable = validateForm();
            }),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                AuthInputField(
                  controller: _usernameController,
                  hintText: 'Email',
                  image: Image.asset('images/user_icon.png',
                      scale: AppConstants.iconScalingFactor),
                  validator: (value) => Validator.validateMail(value),
                ),
                AuthInputField(
                  controller: _passwordController,
                  hintText: 'Password',
                  image: Image.asset('images/password_icon.png',
                      scale: AppConstants.iconScalingFactor),
                  validator: (value) => Validator.validatePassword(value),
                  isObscure: true,
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    const AuthCheckbox(),
                    GestureDetector(
                      onTap: () => Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (_) => const RecoveryPasswordScreen(),
                        ),
                      ),
                      child: RichText(
                        text: TextSpan(
                          text: 'Forget password?',
                          style:
                              Theme.of(context).textTheme.subtitle2?.copyWith(
                                    color: AppConstants.blue,
                                  ),
                        ),
                      ),
                    ),
                  ],
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
