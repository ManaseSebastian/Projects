import 'package:flutter/material.dart';
import 'package:home_automation/auth/login/screens/login_screen.dart';
import 'package:home_automation/common/app_constants.dart';
import 'package:home_automation/services/auth.dart';

import '../../../common/utils/validator/validator.dart';
import '../../auth_main_screen.dart';
import '../../widgets/auth_input_field.dart';

class ConfirmationScreen extends StatefulWidget {
  const ConfirmationScreen({Key? key}) : super(key: key);

  @override
  State<ConfirmationScreen> createState() => _ConfirmationScreenState();
}

class _ConfirmationScreenState extends State<ConfirmationScreen> {
  final TextEditingController _codeController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _confirmationPasswordController =
      TextEditingController();
  bool _isButtonEnable = false;

  bool validateForm() {
    return ((Validator.validateConfirmPassword(_passwordController.text,
                _confirmationPasswordController.text) ==
            null) &&
        (Validator.validateCode(_codeController.text) == null));
  }

  void handleButton() {
    AuthService service = AuthService();
    service.changePassword(context, () {
      if (!mounted) return;
      Navigator.push(
        context,
        MaterialPageRoute(
          builder: (_) => const LoginScreen(),
        ),
      );
    }, _codeController.text, _passwordController.text);
  }

  @override
  Widget build(BuildContext context) {
    return AuthMainScreen(
      backgroundImage:
          const AssetImage('images/recovery_password_background.png'),
      textButton: 'Change Password',
      isButtonEnable: _isButtonEnable,
      centerWidget: SizedBox(
        height: 215,
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
                  controller: _codeController,
                  hintText: 'Confirmation Code',
                  image: Image.asset(
                    'images/confirmation_code_icon.png',
                    scale: AppConstants.iconScalingFactor,
                  ),
                  validator: (value) => Validator.validateCode(value),
                ),
                AuthInputField(
                  controller: _passwordController,
                  hintText: 'New Password',
                  image: Image.asset('images/password_icon.png',
                      scale: AppConstants.iconScalingFactor),
                  validator: (value) => Validator.validatePassword(value),
                  isObscure: true,
                ),
                AuthInputField(
                  controller: _confirmationPasswordController,
                  hintText: 'Confirmation Password',
                  image: Image.asset(
                    'images/confirmation_password_icon.png',
                    scale: AppConstants.iconScalingFactor,
                  ),
                  validator: (value) => Validator.validateConfirmPassword(
                      _passwordController.text, value),
                  isObscure: true,
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
