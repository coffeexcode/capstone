import React from 'react';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { createStackNavigator } from '@react-navigation/stack';

import Schedule from '@screens/Schedule';
import Profile from '@screens/Profile';
import PresentQR from '@screens/PresentQR';
import ScanQR from '@screens/ScanQR';
import About from '@screens/About';
import Sponsors from '@screens/Sponsors';
import Contact from '@screens/Contact';

import { Feather } from '@expo/vector-icons';
import { AntDesign } from '@expo/vector-icons';
import { Ionicons } from '@expo/vector-icons';

const Tab = createBottomTabNavigator();
const ScanQRStack = createStackNavigator();
const AboutStack = createStackNavigator();

const createScheduleIcon = ({ color, focused }) => (<AntDesign name="calendar" size={24} color={focused ? color : "black"} />);
const createProfileIcon = ({ color, focused }) => (<Feather name="user" size={24} color={focused ? color : "black"} />);
const createPresentQRIcon = ({ color, focused }) => (<Ionicons name="qr-code-outline" size={24} color={focused ? color : "black"} />);
const createAboutIcon = ({ color, focused }) => (<Ionicons name="information-circle-outline" size={24} color={focused ? color : "black"} />);
const createScanQRIcon = ({ color, focused }) => (<AntDesign name="scan1" size={24} color={focused ? color : "black"} />);

const ScanQRScreen = () => (
  <ScanQRStack.Navigator initialRouteName="ScanQR">
    <ScanQRStack.Screen name="ScanQR" component={ScanQR} />
  </ScanQRStack.Navigator>
);

const AboutScreen = () => (
  <AboutStack.Navigator initialRouteName="About">
    <AboutStack.Screen name="About" component={About} />
    <AboutStack.Screen name="Sponsors" component={Sponsors} />
    <AboutStack.Screen name="Contact" component={Contact}/>
  </AboutStack.Navigator>
);

const createTab = (title, component, iconFn) => (
  <Tab.Screen 
    name={title}
    component={component}
    options={{ title: title, tabBarIcon: iconFn }}
  />
);

const AttendeeHome = () => (
  <Tab.Navigator
    tabBarOptions={{ activeTintColor: '#6C63FF' }}
  >
    {createTab('Schedule', Schedule, createScheduleIcon)}
    {createTab('QR Code', PresentQR, createPresentQRIcon)}
    {createTab('About', AboutScreen, createAboutIcon)}
    {createTab('Profile', Profile, createProfileIcon)}
  </Tab.Navigator>
);

const OrganizerHome = () => (
  <Tab.Navigator
    tabBarOptions={{ activeTintColor: '#6C63FF' }}
  >
    {createTab('Schedule', Schedule, createScheduleIcon)}
    {createTab('Scan', ScanQRScreen, createScanQRIcon)}
    {createTab('Profile', Profile, createProfileIcon)}
  </Tab.Navigator>
);

export {
  AttendeeHome,
  OrganizerHome
}
