import 'dart:developer';

import 'package:http/http.dart';

class TemperatureService extends Service {
  final String setCurrentTemperatureURL =
      "http://192.168.1.5:8080/api/temperature/setCurrentTemperature";

  Future<void> setCurrentTemperature(String currentTemperature) async {
    Response res = await post(
      Uri.parse(setCurrentTemperatureURL),
      body: currentTemperature,
    );

    if (res.statusCode == 200) {
    } else {
      throw "Unable to retrieve stock data.";
    }
  }
}
