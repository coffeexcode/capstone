import React from 'react';
import { fireEvent, render } from '@testing-library/react-native';

import Landing from '@screens/Onboarding/Landing';

jest.mock('@expo/vector-icons');
jest.useFakeTimers();

describe('<Landing/>', () => {
  it('should render the View properly', () => {
    const tree = render(<Landing />).toJSON();
    expect(tree.type).toBe('View');
  })

  it('should render the title', () => {
    const comp = render(<Landing/>);
    const title = comp.getByTestId('title');

    expect(title.children[1].slice(1)).toBe('ConAssist');
  })

  it('should render the splash image', () => {
    const comp = render(<Landing/>);
    const title = comp.getByTestId('splash');
    expect(title.type).toBe('Image');
  })

  it('should navigate to Sign In page when the button is selected', () => {
    navigation = {
      navigate: jest.fn()
    }
    const comp = render(<Landing navigation={navigation}/>);
    const button = comp.getByTestId('getStartedBtn');

    fireEvent(button, 'press');
    expect(navigation.navigate).toHaveBeenCalledWith('SignIn');
  })
})
