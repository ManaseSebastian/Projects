import 'dart:convert';

import 'package:http/http.dart';

import '../common/app_constants.dart';

class SecurityService{
  final String scheduleAlarmURL =
      "http://${AppConstants.address}/api/security/scheduleAlarm";
  final String getStateAlarmURL =
      "http://${AppConstants.address}/api/security/getStateAlarm";
  final String turnOnAlarmURL =
      "http://${AppConstants.address}/api/security/turnOnAlarm";
  final String turnOffAlarmURL =
      "http://${AppConstants.address}/api/security/turnOffAlarm";


  Future<void> scheduleAlarm(String alarm) async {
    Response res = await post(
      Uri.parse(scheduleAlarmURL),
      body: alarm,
    );

    if (res.statusCode == 200) {
    } else {
      throw "Unable to retrieve data.";
    }
  }

  Future<bool> getStateAlarm() async {
    Response res = await get(Uri.parse(getStateAlarmURL));

    if (res.statusCode == 200) {
      final response = jsonDecode(res.body);
      return response;
    } else {
      throw "Unable to retrieve stock data.";
    }
  }

  Future<void> turnOnAlarm() async {
    Response res = await get(Uri.parse(turnOnAlarmURL));

    if (res.statusCode == 200) {
    } else {
      throw "Unable to retrieve stock data.";
    }
  }

  Future<void> turnOffAlarm() async {
    Response res = await get(Uri.parse(turnOffAlarmURL));

    if (res.statusCode == 200) {
    } else {
      throw "Unable to retrieve stock data.";
    }
  }

}