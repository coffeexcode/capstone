import { StatusBar } from 'expo-status-bar';
import React from 'react';
import Landing from './components/screens/Landing';
import SignIn from './components/screens/SignIn';
import SelectView from './components/screens/SelectView';
import PresentQR from './components/screens/PresentQR';
import ScanQR from './components/screens/ScanQR';
import Schedule from './components/screens/Schedule';
import Profile from './components/screens/Profile';

export default function App() {
  return (
    <>
      <Profile/>
      <StatusBar style="auto" />
    </>
  );
}
