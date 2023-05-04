import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
import 'package:home_automation/auth/register/register_screen.dart';
import 'package:home_automation/common/app_constants.dart';
import 'package:home_automation/common/widgets/home_it_button.dart';

class AuthMainScreen extends StatelessWidget {
  final ImageProvider backgroundImage;
  final String textButton;
  final bool hasBottomText;
  final bool hasBackButton;
  final Widget centerWidget;
  final Widget? nextDestination;
  final VoidCallback? action;
  final bool isButtonEnable;

  const AuthMainScreen({
    Key? key,
    required this.backgroundImage,
    required this.centerWidget,
    required this.textButton,
    this.nextDestination,
    this.action,
    this.hasBottomText = false,
    this.hasBackButton = true,
    this.isButtonEnable = false,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: LayoutBuilder(
        builder: (BuildContext context, BoxConstraints constraints) {
          return Container(
            decoration: BoxDecoration(
              image: DecorationImage(
                image: backgroundImage,
                fit: BoxFit.cover,
              ),
            ),
            child: SingleChildScrollView(
              child: ConstrainedBox(
                constraints: BoxConstraints(
                  minHeight: constraints.maxHeight,
                ),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.spaceAround,
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Padding(
                      padding: const EdgeInsets.only(left: 15),
                      child: hasBackButton
                          ? GestureDetector(
                        onTap: () => Navigator.pop(context),
                        child: Image.asset('images/back_button.png'),
                      )
                          : null,
                    ),
                    centerWidget,
                    Column(
                      children: [
                        Padding(
                          padding: const EdgeInsets.only(bottom: 15.0),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: hasBottomText
                                ? [
                              RichText(
                                text: TextSpan(
                                  style: Theme.of(context).textTheme.titleMedium,
                                  children: [
                                    const TextSpan(
                                      text: "You don't have an account? ",
                                    ),
                                    TextSpan(
                                      text: "Register",
                                      style: const TextStyle(
                                        decoration: TextDecoration.underline,
                                        color: AppConstants.blue,
                                      ),
                                      recognizer: TapGestureRecognizer()
                                        ..onTap = () => Navigator.push(
                                          context,
                                          MaterialPageRoute(
                                            builder: (_) =>
                                            const RegisterScreen(),
                                          ),
                                        ),
                                    ),
                                  ],
                                ),
                              ),
                            ]
                                : [],
                          ),
                        ),
                        Padding(
                          padding: const EdgeInsets.symmetric(horizontal: 15.0),
                          child: HomeItButton(
                            onPressed: isButtonEnable? action ?? () => Navigator.push(
                              context,
                              MaterialPageRoute(builder: (_) => nextDestination!),
                            ): null,
                            text: textButton,
                          ),
                        ),
                      ],
                    ),
                  ],
                ),
              ),
            ),
          );
        }
      ),
    );
  }
}
