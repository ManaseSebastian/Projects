import 'package:flutter/material.dart';
import 'package:home_automation/common/app_constants.dart';
import 'package:mailer/mailer.dart';
import 'package:mailer/smtp_server.dart';

class EmailSender {
  String _email= "";
  String _subject= "";
  String _text ="";

  EmailSender(String email, String subject, String text){
    _email = email;
    _subject = subject;
    _text = text;
  }

  Future<void> sendMail(BuildContext context, VoidCallback onSuccess) async {
    final smtpServer = gmail(AppConstants.mail, AppConstants.password);

    final message = Message()
      ..from = const Address(AppConstants.mail, 'HomeIT_App')
      ..recipients.add(_email)
      ..subject = _subject
      ..text = _text;
    try {
      await send(message, smtpServer);
      onSuccess.call();
     } on MailerException catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          content: Text('Something went wrong!'),
        ),
      );
    }
  }
}
