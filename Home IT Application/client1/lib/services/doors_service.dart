import 'dart:convert';

import 'package:http/http.dart';

import '../common/app_constants.dart';

class DoorsService {
  final String lockDoorsURL =
      "http://${AppConstants.address}/api/doors/lockDoors";
  final String unlockDoorsURL =
      "http://${AppConstants.address}/api/doors/unlockDoors";
  final String getStateDoorsURL =
      "http://${AppConstants.address}/api/doors/getStateDoors";
  final String scheduleLockURL =
      "http://${AppConstants.address}/api/doors/scheduleLock";
  final String verifyPINLockURL =
      "http://${AppConstants.address}/api/doors/verifyPINLock";

  Future<void> lockDoors() async {
    Response res = await get(Uri.parse(lockDoorsURL));

    if (res.statusCode == 200) {
    } else {
      throw "Unable to retrieve stock data.";
    }
  }

  Future<void> unlockDoors() async {
    Response res = await get(Uri.parse(unlockDoorsURL));

    if (res.statusCode == 200) {
    } else {
      throw "Unable to retrieve stock data.";
    }
  }

  Future<void> scheduleLock(String lock) async {
    Response res = await post(
      Uri.parse(scheduleLockURL),
      body: lock,
    );

    if (res.statusCode == 200) {
    } else {
      throw "Unable to retrieve data.";
    }
  }

  Future<bool> getStateDoors() async {
    Response res = await get(Uri.parse(getStateDoorsURL));

    if (res.statusCode == 200) {
      final response = jsonDecode(res.body);
      return response;
    } else {
      throw "Unable to retrieve stock data.";
    }
  }

  Future<void> verifyPINLock(String lock) async {
    Response res = await post(
      Uri.parse(verifyPINLockURL),
      body: lock,
    );

    if (res.statusCode == 200) {
    } else {
      throw "Unable to retrieve data.";
    }
  }
}
