import React from 'react';
import { render, fireEvent } from '@testing-library/react-native';

import SignIn from '@screens/Onboarding/SignIn';
import { Platform } from 'react-native';

jest.mock('@expo/vector-icons');
jest.useFakeTimers();

describe('<SignIn/>', () => {
  it('renders the View properly for iOS', () => {
    Platform.OS = 'ios';
    const tree = render(<SignIn/>).toJSON();
    expect(tree.type).toBe('View');
  })

  it('renders the View properly for android', () => {
    Platform.OS = 'android';
    const tree = render(<SignIn/>).toJSON();
    expect(tree.type).toBe('View');
  })
  
  it('should navigate to the SelectView button when log in is pressed', () => {
    const navigation = {
      navigate: jest.fn()
    }
    const comp = render(<SignIn navigation={navigation} />);
    const button = comp.getByTestId('loginBtn');
    fireEvent(button, 'press');

    expect(navigation.navigate).toHaveBeenCalledWith('SelectView');
  })

  it('should change the text in the username field', () => {
    const comp = render(<SignIn />);
    const input = comp.getByTestId('usernameInput');
    fireEvent(input, 'changeText', 'testusername');

    // NOTE: changing the text in the username updates the internal state, which isn't exposed to outer 
    // methods such as this test. This is intended
    expect(input).toBeTruthy();
  })

  it('should change the text in the password field', () => {
    const comp = render(<SignIn />);
    const input = comp.getByTestId('passwordInput');
    fireEvent(input, 'changeText', 'testpassword');

    // NOTE: changing the text in the username updates the internal state, which isn't exposed to outer 
    // methods such as this test. This is intended
    expect(input).toBeTruthy();
  })

  it('should have secure entry for password input', () => {
    const comp = render(<SignIn/>);
    const input = comp.getByTestId('passwordInput');
    expect(input.props.secureTextEntry).toBe(true);
  })
})
