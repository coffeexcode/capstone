import React from "react";
import { Container, Grid } from "@material-ui/core";
import { Details } from "./Details";

/**
 *  Public page to display the different product levels that we offer and
 * illustrate the differences between each.
 * TODO: Replace [ ] descriptions with feature comparison table below
 */
export const Products = (props) => {
  const products = [
    {
      heading: "Basic Event",
      subheading: "Free",
      description: `
        [Limited tooling and registration options]
      `,
    },
    {
      heading: "Advanced Event",
      subheading: "$$",
      description: `
        [Application registration enabled]
      `,
    },
    {
      heading: "Commercial Event",
      subheading: "$$$",
      description: `
        [Application and Ticket registration enabled]
      `,
    },
  ];

  return (
    <div data-testid="product-page">
      <Container className="admin-home" maxWidth="lg">
        <Grid container spacing={3}>
          {products.map((product, i) => (
            <Grid key={i} item xs={4}>
              <Details
                heading={product.heading}
                subheading={product.subheading}
                description={product.description}
              />
            </Grid>
          ))}
        </Grid>
      </Container>
      {/* <div className="bg-color"></div> */}
    </div>
  );
};
