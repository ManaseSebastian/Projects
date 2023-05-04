import 'package:flutter/material.dart';
import 'package:home_automation/auth/login/screens/login_screen.dart';
import 'package:home_automation/auth/widgets/auth_input_field.dart';
import 'package:home_automation/auth/auth_main_screen.dart';
import 'package:home_automation/common/app_constants.dart';
import 'package:home_automation/common/widgets/home_it_label.dart';
import 'package:home_automation/services/auth.dart';

import '../../common/utils/validator/validator.dart';

class RegisterScreen extends StatefulWidget {
  const RegisterScreen({Key? key}) : super(key: key);

  @override
  State<RegisterScreen> createState() => _RegisterScreenState();
}

class _RegisterScreenState extends State<RegisterScreen> {
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _mailController = TextEditingController();
  bool _isButtonEnable = false;

  bool validateForm() {
    return (Validator.validateUsername(_usernameController.text) == null &&
        Validator.validatePassword(_passwordController.text) == null &&
        Validator.validateMail(_mailController.text) == null);
  }

  void handleButton() {
    AuthService service = AuthService();
    service.register(_mailController.text, _passwordController.text);

    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (_) =>
        const LoginScreen(),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return AuthMainScreen(
      backgroundImage: const AssetImage('images/register_background.png'),
      textButton: 'Register',
      isButtonEnable: _isButtonEnable,
      action: handleButton,
      centerWidget: SizedBox(
      height: 215,
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 20),
        child: Form(
          onChanged: () =>
              setState(() {
                _isButtonEnable = validateForm();
              }),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              AuthInputField(
                controller: _usernameController,
                hintText: 'Username',
                image: Image.asset(
                  'images/user_icon.png',
                  scale: AppConstants.iconScalingFactor,
                ),
                validator: (value) => Validator.validateUsername(value),
              ),
              AuthInputField(
                controller: _passwordController,
                hintText: 'Password',
                image: Image.asset(
                  'images/password_icon.png',
                  scale: AppConstants.iconScalingFactor,
                ),
                validator: (value) => Validator.validatePassword(value),
                isObscure: true,
              ),
              AuthInputField(
                controller: _mailController,
                hintText: 'eg: mail@yahoo.com',
                image: Image.asset(
                  'images/mail_icon.png',
                  scale: AppConstants.iconScalingFactor,
                ),
                validator: (value) => Validator.validateMail(value),
              ),
            ],
          ),
        ),
      ),
    ),);
  }
}
