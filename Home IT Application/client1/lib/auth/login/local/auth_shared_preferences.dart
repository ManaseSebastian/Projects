import 'package:shared_preferences/shared_preferences.dart';

class AuthSharedPreferences {
  static SharedPreferences? _preferences;

  static final AuthSharedPreferences instance = AuthSharedPreferences._privateConstructor();

  AuthSharedPreferences._privateConstructor();

  static Future<AuthSharedPreferences> init() async{
    _preferences ??= await SharedPreferences.getInstance();
    return instance;
  }

  Future<bool> setString(String key, String value) async =>
      await _preferences?.setString(key, value) ?? false;

  String getString({required String key, String defaultValue= ""}) =>
      _preferences?.getString(key) ?? defaultValue;

  Future<bool> setBool(String key, bool value) async =>
      await _preferences?.setBool(key, value) ?? false;

  bool getBool({required String key, bool defaultValue= false}) =>
      _preferences?.getBool(key) ?? defaultValue;

}