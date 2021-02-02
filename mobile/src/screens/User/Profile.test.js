import React from 'react';
import { fireEvent, render } from '@testing-library/react-native';

import Profile from '@screens/User/Profile';

jest.mock('@expo/vector-icons');
jest.useFakeTimers();

global.fetch = jest.fn(() => Promise.resolve({}));

describe('<Profile/>', () => {
  it('should render the View properly', () => {
    const tree = render(<Profile />).toJSON();
    expect(tree.type).toBe('RCTSafeAreaView');
  })

  it('should display the profile name', () => {
    const comp = render(<Profile/>);
    const text = comp.getByTestId('name');
    expect(text.children[0]).toBeTruthy();
  })

  it('should display the profile email', () => {
    const comp = render(<Profile/>);
    const text = comp.getByTestId('email');
    expect(text.children[0]).toBeTruthy();
  })
  
  it('should display the profile phone', () => {
    const comp = render(<Profile/>);
    const text = comp.getByTestId('phone');
    expect(text.children[0]).toBeTruthy();
  })

  it('should display the profile instance', () => {
    const comp = render(<Profile/>);
    const text = comp.getByTestId('instanceID');
    expect(text.children[0]).toBeTruthy();
  })

  it('should navigate back to the Sign In page when the logout button is pressed', () => {
    const navigation = {
      navigate: jest.fn()
    }
    const comp = render(<Profile navigation={navigation} />);
    const button = comp.getByTestId('logoutBtn');

    fireEvent(button, 'press');
    expect(navigation.navigate).toHaveBeenCalledWith('SignIn');
  })

  it('should fetch the expected response from the API', () => {
    const comp = render(<Profile />);
    expect(fetch).toHaveBeenCalled();
  })
})
