import 'package:flutter/material.dart';
import 'package:home_automation/auth/login/screens/login_screen.dart';
import 'package:home_automation/common/app_constants.dart';
import 'package:home_automation/features/home/home_screen.dart';

import '../../features/settings/settings_screen.dart';
import '../../../services/auth.dart';

class HomeItAppBar extends StatelessWidget implements PreferredSizeWidget {
  final bool hasSettings;
  final bool hasBackButton;

  const HomeItAppBar({
    Key? key,
    this.hasSettings = true,
    this.hasBackButton = true,
  })  : preferredSize = const Size.fromHeight(kToolbarHeight),
        super(key: key);

  @override
  final Size preferredSize;

  @override
  Widget build(BuildContext context) {
    AuthService authService = AuthService();

    return AppBar(
      centerTitle: true,
      title: GestureDetector(
        onTap: () => Navigator.push(
          context,
          MaterialPageRoute(
            builder: (_) => const HomeScreen(),
          ),
        ),
        child: Text(
          AppConstants.appTitle,
          style: Theme.of(context)
              .textTheme
              .headlineMedium
              ?.copyWith(fontWeight: FontWeight.bold),
        ),
      ),
      leading: hasBackButton ? const BackButton(color: Colors.black) : null,
      actions: hasSettings
          ? [
              IconButton(
                onPressed: () => Navigator.push(
                  context,
                  MaterialPageRoute(builder: (_) => const SettingsScreen()),
                ),
                icon: const Icon(
                  Icons.settings,
                  color: Colors.black,
                ),
              ),
              IconButton(
                onPressed: () {
                  authService.signOut();
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (_) => const LoginScreen(),
                    ),
                  );
                },
                icon: const Icon(
                  Icons.logout_outlined,
                  color: Colors.black,
                ),
              ),
            ]
          : [],
      backgroundColor: Colors.white,
    );
  }
}
