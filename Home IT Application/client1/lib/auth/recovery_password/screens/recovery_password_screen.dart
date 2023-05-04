import 'dart:math';

import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:home_automation/auth/recovery_password/screens/confirmation_screen.dart';
import 'package:home_automation/auth/widgets/auth_input_field.dart';
import 'package:home_automation/auth/auth_main_screen.dart';
import 'package:home_automation/common/app_constants.dart';
import 'package:home_automation/common/utils/email_sender/email_sender.dart';
import 'package:home_automation/common/utils/validator/validator.dart';

import '../../../services/auth.dart';

class RecoveryPasswordScreen extends StatefulWidget {
  const RecoveryPasswordScreen({Key? key}) : super(key: key);

  @override
  State<RecoveryPasswordScreen> createState() => _RecoveryPasswordScreenState();
}

class _RecoveryPasswordScreenState extends State<RecoveryPasswordScreen> {
  final TextEditingController _mailController = TextEditingController();
  bool _isButtonEnable = false;
  String _code = "";

  bool validateForm() {
    return (Validator.validateMail(_mailController.text) == null);
  }

  Future handleButton() async {
    // AuthService service = AuthService();
    // await service.recoveryPassword(_mailController.text.trim());
    await FirebaseAuth.instance.sendPasswordResetEmail(email: _mailController.text.trim());
  }

  // void _handleButton() {
  //   _code = "${Random().nextInt(10)}${Random().nextInt(10)}${Random().nextInt(10)}${Random().nextInt(10)}";
  //   EmailSender sender = EmailSender(_mailController.text, 'Recovery Code',
  //       'The Recovery Code required is: $_code');
  //   sender.sendMail(context, () {
  //     if (!mounted) return;
  //     Navigator.push(
  //       context,
  //       MaterialPageRoute(
  //         builder: (_) => const ConfirmationScreen(),
  //       ),
  //     );
  //   });
  // }

  @override
  Widget build(BuildContext context) {
    return AuthMainScreen(
      backgroundImage:
          const AssetImage('images/recovery_password_background.png'),
      textButton: 'Recovery Password',
      isButtonEnable: _isButtonEnable,
      action: handleButton,
      centerWidget: SizedBox(
        height: 175,
        child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 20),
          child: Form(
            onChanged: () => setState(() {
              _isButtonEnable = validateForm();
            }),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.spaceAround,
              children: [
                Text(
                  '  Please insert the email in the box below. You will receive a code for verification.',
                  style: Theme.of(context).textTheme.titleMedium,
                ),
                AuthInputField(
                  controller: _mailController,
                  hintText: 'eg: mail@yahoo.com',
                  image: Image.asset(
                    'images/mail_icon.png',
                    scale: AppConstants.iconScalingFactor,
                  ),
                  validator: (value) => Validator.validateMail(value),
                )
              ],
            ),
          ),
        ),
      ),
    );
  }
}
