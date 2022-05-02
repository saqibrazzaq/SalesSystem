import React, { useState } from "react";
import { Formik, Field, Form, ErrorMessage } from "formik";
import * as Yup from "yup";
import api from "../../../api/api";
import { useNavigate } from "react-router-dom";
import {
  Typography,
} from "@mui/material";


function AvailabilityEdit(props) {
  
  let navigate = useNavigate();
  
  function addAvailability(a) {
    
    console.log(a);
  
    api
      .post("/Availabilities", a)
      .then((res) => {
        console.log(res);
        navigate("/admin/home/availabilities", {replace: true});
      })
      .catch((err) => {
        console.log("Error creating availability " + err);
        
      });
  }

  return (
    <div className="ui form error">
      <h2>Create Availability</h2>

      <Formik
        initialValues={{ name: "", position: 1 }}
        validationSchema={Yup.object({
          name: Yup.string()
            .max(15, "Must be 15 characters or less")
            .required("Required"),
          position: Yup.number().required("Required"),
        })}
        onSubmit={(values, { setSubmitting }) => {
          // console.log(JSON.stringify(values, null, 2));
          // console.log(values);
          addAvailability(values);
          setSubmitting(false);
          
        }}
      >
        <Form className="ui form">
          <div className="field">
            <label htmlFor="name">Name</label>
            <Field name="name" type="text" />
            <ErrorMessage
              name="name"
              component="div"
              className="ui pointing red basic label"
            />
          </div>
          <div className="field">
            <label htmlFor="position">Position</label>
            <Field name="position" type="number" />
            <ErrorMessage
              name="position"
              component="div"
              className="ui pointing red basic label"
            />
          </div>

          <button className="ui submit button" type="submit">
            Create Availability
          </button>
        </Form>
      </Formik>
    </div>
  );
}

export default AvailabilityEdit;
