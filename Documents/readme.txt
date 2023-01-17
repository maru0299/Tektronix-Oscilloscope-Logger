Tektronix DPO2000用に作りました。
他のテクトロのオシロでも動くかもしれません。

①
オシロとPCをUSB接続しドライバをインストールしてください。
ドライバはおそらく自動でインストールされます。

②
Oscillo_Logger.exeを起動し、Measurement SettingゾーンでTime Step（測定間隔）とCycle（何回測定するか）を設定してください。
Cycleが空欄の場合は手動で止めるまで測定します。

③
Oscilloscopeゾーンで測定器と接続してください。
Connectボタンを押すといくつか表示されると思いますが、
他のUSBデバイスをすべて取り外して残ったUSBどうのこうのというリソースがオシロです。

④
Save CSVにログの保存先フォルダとファイル名入力してください。
空欄にしておくとログが保存されません。

⑤
オシロスコープ側のMeasurementを手動で設定してください。

⑥
START LOGでMeasurementのログがとれます。


※
上手く動かなければ同梱のni-visa_20.0_online_repack3.exeをインストールしてください。
NI-VISAランタイムだけインストールすれば動くと思います。

圓岡