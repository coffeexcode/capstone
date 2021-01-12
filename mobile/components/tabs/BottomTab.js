import React from 'react';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { createStackNavigator } from '@react-navigation/stack';

import Schedule from '@screens/User/Schedule';
import Profile from '@screens/User/Profile';
import PresentQR from '@screens/Attendee/PresentQR';
import ScanQR from '@screens/Organizer/ScanQR';
import About from '@screens/Attendee/About';
import Sponsors from '@screens/Attendee/Sponsors';
import Contact from '@screens/Attendee/Contact';
import Event from '@screens/Attendee/Event';

import { Feather } from '@expo/vector-icons';
import { AntDesign } from '@expo/vector-icons';
import { Ionicons } from '@expo/vector-icons';

const Tab = createBottomTabNavigator();
const ScheduleStack = createStackNavigator();
const ScanQRStack = createStackNavigator();
const AboutStack = createStackNavigator();

const createScheduleIcon = ({ color, focused }) => (<AntDesign name="calendar" size={24} color={focused ? color : "black"} />);
const createProfileIcon = ({ color, focused }) => (<Feather name="user" size={24} color={focused ? color : "black"} />);
const createPresentQRIcon = ({ color, focused }) => (<Ionicons name="qr-code-outline" size={24} color={focused ? color : "black"} />);
const createAboutIcon = ({ color, focused }) => (<Ionicons name="information-circle-outline" size={24} color={focused ? color : "black"} />);
const createScanQRIcon = ({ color, focused }) => (<AntDesign name="scan1" size={24} color={focused ? color : "black"} />);

const ScheduleStackScreens = () => (
  <ScheduleStack.Navigator initialRouteName="Schedule">
    <ScheduleStack.Screen name="Schedule" component={Schedule} />
    <ScheduleStack.Screen name="Event" component={Event} />
  </ScheduleStack.Navigator>
)
const ScanQRStackScreens = () => (
  <ScanQRStack.Navigator initialRouteName="ScanQR">
    <ScanQRStack.Screen name="ScanQR" component={ScanQR} />
  </ScanQRStack.Navigator>
);

const AboutStackScreens = () => (
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
    {createTab('Schedule', ScheduleStackScreens, createScheduleIcon)}
    {createTab('QR Code', PresentQR, createPresentQRIcon)}
    {createTab('About', AboutStackScreens, createAboutIcon)}
    {createTab('Profile', Profile, createProfileIcon)}
  </Tab.Navigator>
);

const OrganizerHome = () => (
  <Tab.Navigator
    tabBarOptions={{ activeTintColor: '#6C63FF' }}
  >
    {createTab('Schedule', ScheduleStackScreens, createScheduleIcon)}
    {createTab('Scan', ScanQRStackScreens, createScanQRIcon)}
    {createTab('Profile', Profile, createProfileIcon)}
  </Tab.Navigator>
);

export {
  AttendeeHome,
  OrganizerHome
}