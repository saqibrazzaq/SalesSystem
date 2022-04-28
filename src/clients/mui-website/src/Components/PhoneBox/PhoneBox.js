import * as React from "react";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import { Button, CardActionArea, CardActions, Grid } from "@mui/material";
import { BrowserRouter as Router, Route, Link } from "react-router-dom";

function PhoneBox(props) {
  const { id, name, imageUrl } = props.phone;
  console.log(props);
  return (
    <Grid item xs={4} md={3}>
      <Card sx={{ maxWidth: 150 }}>
        <CardActionArea component={Link} to={`/phone/${id}`}>
          <CardMedia component="img"  image={imageUrl} alt={name} />
          <CardContent>
            <Typography gutterBottom  component="div">
              {name}
            </Typography>
          </CardContent>
        </CardActionArea>
      </Card>
    </Grid>
  );
}

export default PhoneBox;
