import { useHistory } from "react-router-dom";
import React from "react";

/**
 * Redirect the browser to desired endpoint using react router history hook
 * @param {string} endpoint the **relative** url to navigate to
 * @invariant this method cannot be called outside of a react hook based component 
 */
export const useRedirect = (endpoint) => {
  const history = useHistory();
  return history.push(endpoint);
}