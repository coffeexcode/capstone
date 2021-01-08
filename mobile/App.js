import React from 'react';
import Landing from './components/screens/Landing';
import SignIn from './components/screens/SignIn';
import SelectView from './components/screens/SelectView';
import { AttendeeHome, OrganizerHome } from './tabs/BottomTab';

import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

const Stack = createStackNavigator();

export default function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator
        initialRouteName="Landing"
        screenOptions={() => ({ headerShown: false })}
      >
        <Stack.Screen name="Landing" component={Landing}/>
        <Stack.Screen name="SignIn" component={SignIn}/>
        <Stack.Screen name="SelectView" component={SelectView}/>
        <Stack.Screen name="AttendeeHome" component={AttendeeHome}/>
        <Stack.Screen name="OrganizerHome" component={OrganizerHome}/>
      </Stack.Navigator>
    </NavigationContainer>
  );
}
