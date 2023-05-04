import 'package:flutter/material.dart';
import 'package:home_automation/auth/login/local/pref_constants.dart';
import 'package:home_automation/common/app_constants.dart';

import '../login/local/auth_shared_preferences.dart';

class AuthCheckbox extends StatefulWidget {

  const AuthCheckbox({Key? key}) : super(key: key);

  @override
  State<AuthCheckbox> createState() => _AuthCheckboxState();
}

class _AuthCheckboxState extends State<AuthCheckbox> {
  bool _isChecked = false;

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Checkbox(
          fillColor: const MaterialStatePropertyAll(AppConstants.yellow),
          checkColor: Colors.black,
          value: _isChecked,
          onChanged: (bool? value) {
            setState(() {
              _isChecked = value!;
              AuthSharedPreferences.instance
                  .setBool(PreferencesConstants.rememberMeKey, _isChecked);
            });
          },
          side: MaterialStateBorderSide.resolveWith(
            (states) => const BorderSide(width: 1.0, color: Colors.black),
          ),
        ),
        const Text('Remember me'),
      ],
    );
  }
}
