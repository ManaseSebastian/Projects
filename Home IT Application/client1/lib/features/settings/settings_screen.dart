import 'dart:math';

import 'package:flutter/material.dart';
import 'package:home_automation/common/app_constants.dart';
import 'package:home_automation/common/utils/validator/validator.dart';
import 'package:home_automation/common/widgets/home_it_app_bar.dart';
import 'package:home_automation/common/widgets/home_it_button.dart';
import 'package:home_automation/common/widgets/home_it_main_screen.dart';
import 'package:home_automation/common/widgets/home_it_title.dart';

import '../../auth/widgets/auth_input_field.dart';

class SettingsScreen extends StatefulWidget {
  const SettingsScreen({super.key});

  @override
  State<SettingsScreen> createState() => _SettingsScreenState();
}

class _SettingsScreenState extends State<SettingsScreen> {
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _confirmationPasswordController =
      TextEditingController();
  bool _isVisible = false;
  bool _isButtonEnable = false;

  bool validateForm() {
    return (Validator.validateConfirmPassword(
            _passwordController.text, _confirmationPasswordController.text) ==
        null);
  }

  @override
  Widget build(BuildContext context) {
    return HomeItMainScreen(
      title: 'Settings',
      hasSettings: false,
      widgetImage: Image.asset('images/settings_icon.png'),
      bottomWidget: Column(
        children: [
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceAround,
            children: [
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    'Username: ',
                    style: Theme.of(context).textTheme.titleLarge,
                  ),
                  Padding(
                    padding: const EdgeInsets.only(top: 10.0),
                    child: Text(
                      'Mail: ',
                      style: Theme.of(context).textTheme.titleLarge,
                    ),
                  ),
                ],
              ),
              Column(
                children: [
                  Text(
                    'username_test',
                    style: Theme.of(context).textTheme.titleLarge,
                  ),
                  Padding(
                    padding: const EdgeInsets.only(top: 10.0),
                    child: Text(
                      'mail@yahoo.com',
                      style: Theme.of(context).textTheme.titleLarge,
                    ),
                  ),
                ],
              ),
            ],
          ),
          Padding(
            padding: const EdgeInsets.only(
              top: 40,
              left: 20,
              right: 20,
            ),
            child: HomeItButton(
              onPressed: () => setState(() {
                _isVisible = !_isVisible;
              }),
              text: 'Change Password',
              hasIcon: true,
              changeColor: _isVisible,
            ),
          ),
          if (_isVisible)
            Padding(
              padding: const EdgeInsets.only(
                left: 25,
                right: 25,
                top: 40,
              ),
              child: Form(
                onChanged: () => setState(() {
                  _isButtonEnable = validateForm();
                }),
                child: Column(
                  children: [
                    AuthInputField(
                      hintText: 'New Password',
                      controller: _passwordController,
                      image: Image.asset('images/password_icon.png',
                          scale: AppConstants.iconScalingFactor),
                      validator: (value) => Validator.validatePassword(value),
                      isObscure: true,
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(vertical: 40),
                      child: AuthInputField(
                        hintText: 'Confirmation Password',
                        controller: _confirmationPasswordController,
                        image: Image.asset(
                          'images/password_icon.png',
                          scale: AppConstants.iconScalingFactor,
                        ),
                        validator: (value) => Validator.validateConfirmPassword(
                            _passwordController.text, value),
                        isObscure: true,
                      ),
                    ),
                    Align(
                      alignment: Alignment.bottomRight,
                      child: ElevatedButton(
                        onPressed: _isButtonEnable
                            ? () => setState(() {
                                  _isVisible = !_isVisible;
                                })
                            : null,
                        style: ElevatedButton.styleFrom(
                          backgroundColor: AppConstants.yellow,
                          foregroundColor: Colors.black,
                          elevation: 20, // Elevation
                          shadowColor: Colors.black, // Background color
                        ),
                        child: const Text('Change'),
                      ),
                    ),
                  ],
                ),
              ),
            ),
        ],
      ),
    );
  }
}
